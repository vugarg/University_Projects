package ee.taltech.calculator.theory.question2contribution;

import ee.taltech.calculator.theory.question2contribution.classes.Headphone;
import lombok.AllArgsConstructor;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.Optional;

@RestController
@AllArgsConstructor //instead of @Autowired
public class API3_Headphones {

    // todo this is contribution question
    //  this assignment is only for one team member (if this code is not committed by that team member how do I know this code was theirs?)

    // todo
    //  this assignment consists of 2 parts
    //  practical assignment A, B, C, D, E
    //          All classes are available in classes package
    //          If you want to test these practical assignments add these to your project.
    //          Example: If you Application.java is in the package ee.taltech, make sure theory is in package ee.taltech as well (ee.taltech.theory)
    //  theoretical assignment F, G, H

    //todo practical assignment
    // Management wants to define an API endpoint so frontend can display data about headphones (think headphones e-shop)
    // A Add necessary annotations to this class so this class can serve data
    // B Add a method to query all the headphones (method content is not important - I am grading urls, annotations, names, and parameters)
    // C Add a method to query a single headphones by it's unique identifier (method content is not important - I am grading urls, annotations, names, and parameters)
    // D Modify an existing method to query/filter headphones by price while keeping existing functionality (price can be a string)
    // E Modify an existing method to query/filter anc (active noise cancellation) while keeping existing functionality (anc can be a string)


    @GetMapping(value = "/headphones")
    public Headphone result(@RequestParam Optional<String> price, Optional<String> anc ) {
        return headphoneService.getHeadphone(price,anc);
    }   // returns value by given parameters if none return all
        // checked in headphoneService

    @GetMapping(value = "/headphones/byid")
    public Headphone byParameter(@PathVariable Long id) {
        return headphoneService.getHeadphone(id);
    }   // returns by given id, checked in headphoneService
}

//todo theoretical assignment
// F write pseudocode for saving a new pair of headphones (add annotations or http method names, urls, necessary parameters)
// Service,
// Slf4j,
// AllArgsConstructor,
// GetMapping
// class Headphones(brand,price)
// Headphones GetMapping = /newHeadphones
//  Request param(brand,price)
//      Headphones headphone = new Headphone
//  public Cakes(brand,price)
//      this.brand = Sony
//      this.price = 100
//  return headphone
// G write pseudocode for updating existing pair of headphones (add annotations or http method names, urls, necessary parameters)
// Service,
// Slf4j,
// AllArgsConstructor,
// GetMapping
// class Headphones(brand,price)
// Headphones GetMapping = /update
//  Request param(brand,price)
//      phone.name = newSony
//      phone.weight = 200
//          return headphone
// H write pseudocode for deleting a pair of headphones (add annotations or http method names, urls, necessary parameters)
// Service,
// Slf4j,
// AllArgsConstructor,
// GetMapping
// class Headphones(brand,price)
// Headphones GetMapping = /delete
//  Request param(headphone)
//      delete headphone




