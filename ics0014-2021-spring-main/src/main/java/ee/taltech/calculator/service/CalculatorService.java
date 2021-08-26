package ee.taltech.calculator.service;
import ee.taltech.calculator.dto.CalculationResult1;
import ee.taltech.calculator.dto.CalculationResult2;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Service;
import org.springframework.util.CollectionUtils;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@Service
@Slf4j
public class CalculatorService {
    public CalculationResult1 getCalculationResult1(List<Integer> input) {
        log.info("Your input was {}", input);

        if(CollectionUtils.isEmpty(input)){
            return null;
        }

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

    public CalculationResult2 getCalculationResult2(List<Integer> input) {
        log.info("Your input was {}", input);

        if(CollectionUtils.isEmpty(input)){
            return null;
        }

        CalculationResult2 result = new CalculationResult2();
        List minEven = new ArrayList();
        for (Integer i : input) {
            if (i % 2 == 0) {
                minEven.add(i);
            }
        }
        Collections.sort(minEven);

        Double sum = 0.0;
        Double avg = 0.0;
        Integer oddCounter = 0;
        for (Integer i : input) {
            if (i % 2 != 0) {
                oddCounter ++;
                sum += i;
                avg = sum/oddCounter;
            }
        }

        List powerOf4 = new ArrayList();
        for (Integer i : input) {
            powerOf4.add((i*i*i*i));
        }

        result.setMinEven((Integer) minEven.get(0));
        result.setAverageOfOdd(avg);
        result.setPowerOf4(powerOf4);

        log.info("Your result is {}", result);
        return result;

    }
}
