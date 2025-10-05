package com.company;

public class Main {

    public static void main(String[] args) {
        FizzBuzzResponder responder = new FizzBuzzResponder();
        for (int i = 1; i < 100; i++) {
            System.out.printf("%s\n",  responder.Respond(i));
        }
    }
}
