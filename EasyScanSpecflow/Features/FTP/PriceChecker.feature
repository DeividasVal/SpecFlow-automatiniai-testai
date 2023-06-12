Feature: PriceChecker

@TC176897
Scenario: Price checks
	When user selects price checker
	Then user checks items by barcode and their values match:
	| Barcode | Name                     | Price | Stock |
	| 1       | Virtos HOT DOG dešrelės  | 0.00  | 0     |
	| 2       | ąčęėįšųūž ĄČĘĖĮŠŲŪŽ      | 0.00  | 0     |
	| 5       | K/r"Kiaulienos pažandė"  | 1.69  | 0     |
	| 6       | Virtos VILNIAUS sardelės | 0.00  | 0     |

@TC176898
Scenario Outline: Check unknown item
    When user selects price checker
	And Plus button is pressed
    And Product code <Barcode> is entered and submitted
    Then app return message that item not found

    Examples:
    | Barcode |
    | 1   |
	