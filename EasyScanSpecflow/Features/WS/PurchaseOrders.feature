@WS
Feature: PurchaseOrders

@ignore
@TC165619
Scenario Outline: PurchaseOrders document creation
    When user selects purchaseOrders
    And user presses add operation button
    And user enters document <Number>
    And user submits
    Then document <Number> is created successfuly
    Examples:
    | Number            |
    | PurchaseOrders123 |

@ignore
@TC165621
Scenario: PurchaseOrders adding item
    When user selects purchaseOrders
    And user presses add operation button
    And user enters document PurchaseOrders123
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '2411111109876'
    And user submits
    Then item 111111 with quantity 1 is added successfuly