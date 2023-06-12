Feature: Stocktaking

@TC176915
Scenario Outline: Stocktaking document creation
    When user selects stocktaking
    And user presses add operation button
    And user enters document <Number>
    And user submits
    Then document <Number> is created successfuly

    Examples:
    | Number    |
    | Taking123 |

@TC176916
Scenario Outline: Stocktaking adding item
    When user selects stocktaking
    And user presses add operation button
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '<Barcode>'
    And user submits
    And user syncs items
    Then items are synced successfully
    #Then item <Barcode> with quantity 1 is added successfuly
    Examples:
    | Number    | Barcode |
    | Taking123 | 1       |
    
@TC176917
Scenario: Code quantity check in stocktaking
	When user selects stocktaking
    And user presses add operation button
	And user enters document Taking123
	And user submits
	And user selects latest document
	And user submits items:
   | Barcode       |  
   | 2305613000005 |  
   | 2305613000025 |  
   | 2305613000425 |  
   | 2305613010005 |  
   | 2305613015425 |  
   | 2305613115425 |
   | 2200001015425 |
	Then items with quantities are added: 
   | ExpectedQuantity | ExpectedBarcode |
   | 0                | 5613            |
   | 0.002            | 5613            |
   | 0.042            | 5613            |
   | 1                | 5613            |
   | 1.542            | 5613            |
   | 11.542           | 5613            |
   | 1542             | 1               |
   And user syncs items
   And items are synced successfully

@TC176918
Scenario: Delete item in stocktaking
    Given user selects stocktaking
    And document is selected and item is already added and synced
    When user presses three dots near the item
    And user selects delete
    And user syncs items
    Then items are synced successfully
    And item is deleted and quantity changes to -quantity

@TC176919
Scenario: Reverse delete in stocktaking
    Given user selects stocktaking
    And document is selected and item is already deleted and synced
    When user presses three dots near the item
    And user selects delete
    And user syncs items
    Then items are synced successfully
    And item is deleted and quantity changes to quantity without -
