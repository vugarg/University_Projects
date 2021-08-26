package ee.taltech.calculator.dto;

import lombok.Getter;
import lombok.Setter;

import java.util.List;

@Getter
@Setter
public class CalculationResult2 {
    private Integer minEven;
    private List<Integer> powerOf4;
    private Double averageOfOdd;
}
