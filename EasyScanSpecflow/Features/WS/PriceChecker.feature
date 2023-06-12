Feature: PriceChecker

price checker for webserver

# testrail case id
@ignore
@TC165672
Scenario: Price checks
	When user selects price checker
	Then user checks items by barcode and their values match:
	| Barcode | Name                     | Price | Stock |
	| 1       | Virtos HOT DOG dešrelės  | 0.00  | 0     |
	| 2       | ąčęėįšųūž ĄČĘĖĮŠŲŪŽ      | 0.00  | 0     |
	| 5       | K/r"Kiaulienos pažandė"  | 1.69  | 0     |
	| 6       | Virtos VILNIAUS sardelės | 0.00  | 0     |

@ignore
Scenario Outline: Check unknown item
    When user selects price checker
	And Plus button is pressed
    And Product code <Barcode> is entered and submitted
    Then app should return message 'Barcode not found or No patterns found for this barcode length'

    Examples:
    | Barcode |
    | 1222    |