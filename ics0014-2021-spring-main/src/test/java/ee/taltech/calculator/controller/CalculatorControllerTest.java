package ee.taltech.calculator.controller;

import org.hamcrest.Matchers;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;

import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;

@AutoConfigureMockMvc
@SpringBootTest
class CalculatorControllerTest {

    @Autowired
    private MockMvc mvc;

    @Test
    @DisplayName("calculate1 empty input returns FU Cat with all due respect")
    void calculate1EmptyTest() throws Exception {
        mvc.perform(MockMvcRequestBuilders.get("/calculator/calculate1"))
                .andExpect(status().is4xxClientError());
    }

    @Test
    @DisplayName("calculate2 empty input again returns FU Cat with all due respect")
    void calculate2EmptyTest() throws Exception {
        mvc.perform(MockMvcRequestBuilders.get("/calculator/calculate2"))
                .andExpect(status().is4xxClientError());
    }

    @Test
    @DisplayName("calculate1 with input returns response")
    void calculate1MinEven() throws Exception {
        mvc.perform(MockMvcRequestBuilders.get("/calculator/calculate1?input=1,2,3"))
                .andExpect(status().is2xxSuccessful())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$.minEven").value(2));
    }

    @Test
    @DisplayName("calculate2 with input returns response")
    void calculate2PowerOf4() throws Exception {
        mvc.perform(MockMvcRequestBuilders.get("/calculator/calculate2?input=1,2"))
                .andExpect(status().is2xxSuccessful())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$.powerOf4").value(Matchers.containsInAnyOrder(1,16)));
    }

    @Test
    @DisplayName("throws and error when no input given")
    void calculate1NotFailOnEmptyInput() throws Exception {
        mvc.perform(MockMvcRequestBuilders.get("/calculator/calculate1"))
                .andExpect(status().is4xxClientError());
    }

    @Test
    @DisplayName("throws and error when no input given")
    void calculate1NotFailOnEmptyInput2() throws Exception {
        mvc.perform(MockMvcRequestBuilders.get("/calculator/calculate2"))
                .andExpect(status().is4xxClientError());
    }

    @Test
    @DisplayName("calculate1 with input returns response")
    void calculate1Max() throws Exception {
        mvc.perform(MockMvcRequestBuilders.get("/calculator/calculate1?input=1,2,3"))
                .andExpect(status().is2xxSuccessful())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$.max").value(3));
    }

    @Test
    @DisplayName("calculate1 with input returns response")
    void calculate1Odds() throws Exception {
        mvc.perform(MockMvcRequestBuilders.get("/calculator/calculate1?input=1,2,3"))
                .andExpect(status().is2xxSuccessful())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$.odds").value(Matchers.containsInAnyOrder(1,3)));
    }

    @Test
    @DisplayName("calculate1 with input returns response")
    void calculate2MinEven() throws Exception {
        mvc.perform(MockMvcRequestBuilders.get("/calculator/calculate2?input=1,2,3"))
                .andExpect(status().is2xxSuccessful())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$.minEven").value(2));
    }

    @Test
    @DisplayName("calculate1 with input returns response")
    void calculate2averageOfOdd() throws Exception {
        mvc.perform(MockMvcRequestBuilders.get("/calculator/calculate2?input=1,2,3"))
                .andExpect(status().is2xxSuccessful())
                .andExpect(content().contentType(MediaType.APPLICATION_JSON))
                .andExpect(jsonPath("$.averageOfOdd").value(2.0));
    }
}
