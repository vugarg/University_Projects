package ee.taltech.calculator.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class FirstController {

    @GetMapping(value = "/")
    public String index() {
        return "Welcome to our calculator app!!";
    }
}
