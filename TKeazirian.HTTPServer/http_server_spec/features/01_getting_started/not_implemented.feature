@not-implemented @01-getting-started
Feature: Not Implemented

  Scenario: Make a request with a method (CONNECT) not included in HttpMethods
    Given I make a CONNECT request to "/simple_get"
    Then my response should have status code 501
    And my response should have an empty body
