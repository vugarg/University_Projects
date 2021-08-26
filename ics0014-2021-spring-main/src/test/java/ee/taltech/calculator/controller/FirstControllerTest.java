package ee.taltech.calculator.controller;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;

import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@AutoConfigureMockMvc
@SpringBootTest
public class FirstControllerTest  {

    @Autowired
    private MockMvc mvc;

    @Test
    @DisplayName("index returns Welcome to our calculator app!!")
    void indexTest() throws Exception {
         mvc.perform(MockMvcRequestBuilders.get("/"))
                 .andExpect(status().is2xxSuccessful())
                 .andExpect(content().string("Welcome to our calculator app!!"));
    }


}
