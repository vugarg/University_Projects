package ee.taltech.calculator.theory.question2contribution;


import ee.taltech.calculator.theory.question2contribution.classes.Cake;
import lombok.AllArgsConstructor;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.Optional;

@RestController
@AllArgsConstructor //instead of @Autowired
public class API2_Cakes {

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
    // Management wants to define an API endpoint so frontend can display data about cakes (think cake e-shop)
    // A Add necessary annotations to this class so this class can serve data
    // B Add a method to query all the cakes (method content is not important - I am grading urls, annotations, names, and parameters)
    // C Add a method to query a single cake by it's unique identifier (method content is not important - I am grading urls, annotations, names, and parameters)
    // D Modify an existing method to query/filter cakes by weight while keeping existing functionality
    // E Modify an existing method to query/filter cakes by name while keeping existing functionality

    @GetMapping(value = "/cakes")
    public Cake result(@RequestParam Optional<String> weight, Optional<String> name ) {
        return cakeService.getCake(weight,name);
    }   // returns value by given parameters if none return all
    // checked in cakeService

    @GetMapping(value = "/cakes/id")
    public Cake byParameter(@PathVariable Long id) {
        return cakeService.getCake(id);
    }   // returns by given id, checked in cakeService

}

    //todo theoretical assignment
    // F write pseudocode for saving a new cake (add annotations or http method names, urls, necessary parameters)
    // G write pseudocode for updating existing cake (add annotations or http method names, urls, necessary parameters)
    // H write pseudocode for deleting a cake (add annotations or http method names, urls, necessary parameters)

/*
    We have a dto with class cake if not create
    We have lombok getter setter if not create
    @RestController
    @AllArgsConstructor
    Create service for cake

    @GetMapping with cake on url "/newcake"
    Make a request for parameters id,name,sweetness,size etc
    return new cake with parameters

    We have the class and service already
    @PutMapping with cake on url "/updatecake" List parameters
    return cakeService.getCake(parameters to update)

    @DeleteMapping with cake on url "/deletecake" value by name
    delete the cake in the given parameter
*/
