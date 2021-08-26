package ee.taltech.calculator.controller;

import ee.taltech.calculator.dto.CalculationResult1;
import ee.taltech.calculator.dto.CalculationResult2;
import ee.taltech.calculator.service.CalculatorService;
import lombok.AllArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@RestController
@RequestMapping("calculator")
@AllArgsConstructor //instead of @Autowired
public class CalculatorController {

    private final CalculatorService calculatorService;

    @GetMapping(value = "/calculate1")
    public CalculationResult1 calculate1(@RequestParam List<Integer> input) {
        return calculatorService.getCalculationResult1(input);
    }

    @GetMapping(value = "/calculate2")
    public CalculationResult2 calculate2(@RequestParam List<Integer> input) {
        return calculatorService.getCalculationResult2(input);
    }
}
