package ee.taltech.calculator.util;

import ee.taltech.calculator.dto.CalculationResult1;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@Slf4j

public class Calculate1 {

    private CalculationResult1 getCalculationResult1(List<Integer> input) {
        log.info("Your input was {}", input);
        CalculationResult1 result = new CalculationResult1();

        List odds = new ArrayList();

        for (Integer integer : input) {
            if (integer % 2 != 0) {
                odds.add(integer);
            }
        }

        List minEven = new ArrayList();
        for (Integer integer : input) {
            if (integer % 2 == 0) {
                minEven.add(integer);
            }
        }
        Collections.sort(minEven);

        result.setMax(Collections.max(input));
        result.setOdds(odds);
        result.setMinEven((Integer) minEven.get(0));

        log.info("Your result is {}", result);
        return result;
    }
}
