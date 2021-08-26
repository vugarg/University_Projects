package ee.taltech.calculator.dto;

import lombok.Getter;
import lombok.Setter;

import java.util.List;

@Getter
@Setter
public class CalculationResult1 {
    private Integer max;
    private Integer minEven;
    private List<Integer> odds;
}