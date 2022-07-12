@method-not-allowed @01-getting-started
Feature: Method Not Allowed

  @wip
  Scenario: Finding POST for an endpoint with only GET
    Given I make a POST request to "/simple_get"
    Then my response should have status code 405
    And my response should have allowed headers of GET, HEAD, OPTIONS
    And my response should have an empty body

  @wip
  Scenario: Finding POST for an endpoint with only GET
    Given I make a POST request to "/simple_get_with_body"
    Then my response should have status code 405
    And my response should have allowed headers of GET, HEAD, OPTIONS
    And my response should have an empty body
