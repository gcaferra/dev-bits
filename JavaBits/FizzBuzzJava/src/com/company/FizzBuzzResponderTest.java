package com.company;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

class FizzBuzzResponderTest {

    private FizzBuzzResponder _sut = null;

    @BeforeEach
    void init() {
        _sut = new FizzBuzzResponder();
    }

    @Test
    void should_return_a_number_as_String(){

        assertEquals("1", _sut.Respond(1));
    }

    @Test
    void if_the_number_divide_by_3_return_Fizz(){
        String actual = _sut.Respond(3);
        assertEquals("Fizz", actual);
    }

    @Test
    void if_the_number_divide_by_5_return_Buzz(){
        String actual = _sut.Respond(5);
        assertEquals("Buzz", actual);
    }

    @Test
    void if_the_number_divide_by_15_return_FizzBuzz(){
        String actual = _sut.Respond(15);
        assertEquals("FizzBuzz", actual);
    }

}