Feature: Settings
	requires commenting out code for app launching and shutting down after each test, settings must be visible before test
	comment out marked lines in AppiumDriver.cs, InitializeHook.cs and ScenarioHooks.cs files
	before running test remove @ignore tag

@ignore
@TC176925
Scenario Outline: Bad API key in settings
	Given the user is on settings page
	When user inputs "test1" in API text field and presses save
	Then toast "<Error>" shows up
	Examples: 
	| Error                                                     |
	| https://datatracker.ietf.org/doc/html/rfc7235#section-3.1 |
    
@ignore
@TC176926
Scenario: No WIFI to download settings
	Given WIFI on phone is off
	When user tries to download settings
	Then toast "<Error>" shows up
	Examples: 
	| Error                  |
	| Unable to resolve host |

@ignore
@TC176927
Scenario: WIFI to download settings
	Given WIFI on phone is on
	When user tries to download settings
	Then toast "<Success>" shows up
	Examples: 
	| Success             |
	| Settings downloaded |

@ignore
@TC176928
Scenario: Price checks with last digit discard setting 
	Given last digit discard setting is on
	When user selects price checker
	Then user checks items by discarded barcode and their values match: 
	| Barcode       | Name                           | Price | Stock | ExpectedBarcode |
	| 1185451       | Šviežia mažoji višt.filė KEKAV | 0.00  | 0     | 118545          |
	| 1205857       | Čeburekai                      | 0.83  | 0     | 120585          |
	| 420704291     | Kramt.guma ORBIT White Fruit 1 | 0.32  | 0     | 42070429        |
	| 78257597032   | Pripučiamas čiužinys, 250x30x3 | 0.00  | 0     | 7825759703      |
	| 200030171251  | Zefyrai COLA BOTTLES, 180 g    | 0.64  | 0     | 20003017125     |
	| 200901002762  | Šok.saldainiai SPRENGEL, su la | 0.96  | 0     | 20090100276     |
	| 802475724521  | Šokoladinių saldainių asorti D | 1.21  | 0     | 80247572452     |
	| 4820078573596 | Saulėgrąžų, aliejus KERNEL 1L  | 1.65  | 0     | 482007857359    |

@ignore
@TC176929
Scenario: Price checks with numeric barcode
	Given numeric barcode is on
	When user selects price checker
	Then user checks items by barcode and their values match with the numeric barcode setting:
	| Barcode | Name                           | Price | Stock |
	| 1       | Virtos HOT DOG dešrelės        | 0.00  | 0     |
	| 2       | ąčęėįšųūž ĄČĘĖĮŠŲŪŽ            | 0.00  | 0     |
	| 5       | K/r"Kiaulienos pažandė"        | 0.00  | 0     |
	| 1067288 | Žele saldainiai, vaisių sk., 2 | 0.63  | 0     |

@ignore
@TC176989
Scenario: Price checks with numeric barcode and last digit discard setting
	Given last digit discard and numeric barcode is on
	When user selects price checker
	Then user checks items by discarded barcode and numeric and their values match: 
	| Barcode       | Name                           | Price | Stock | ExpectedBarcode |
	| 1185451       | Šviežia mažoji višt.filė KEKAV | 0.00  | 0     | 118545          |
	| 1205857       | Čeburekai                      | 0.83  | 0     | 120585          |
	| 420704291     | Kramt.guma ORBIT White Fruit 1 | 0.32  | 0     | 42070429        |
	| 78257597032   | Pripučiamas čiužinys, 250x30x3 | 0.00  | 0     | 7825759703      |
	| 200030171251  | Zefyrai COLA BOTTLES, 180 g    | 0.64  | 0     | 20003017125     |
	| 200901002762  | Šok.saldainiai SPRENGEL, su la | 0.96  | 0     | 20090100276     |
	| 802475724521  | Šokoladinių saldainių asorti D | 1.21  | 0     | 80247572452     |
	| 4820078573596 | Saulėgrąžų, aliejus KERNEL 1L  | 1.65  | 0     | 482007857359    |

@ignore
@TC176930
Scenario: Code quantity check in stockadding with item grouping setting
    Given item grouping is on
	When user selects stockadding
    And user presses add operation button
	And user enters document Adding123
	And user submits
	And user selects latest document
	And user submits items:
   | Barcode |
   | 1018    |
   | 1018    |
   | 1018    |
   | 1018    |
   | 3468    |
   | 3468    |
	Then items with quantities are added for item grouping:  
   | ExpectedQuantity | ExpectedBarcode |
   | 4                | 1018            |
   | 2                | 3468            |
    
@ignore
@TC176931
Scenario: Code quantity check in stocktaking with item grouping setting
    Given item grouping is on
	When user selects stocktaking
    And user presses add operation button
	And user enters document Taking123
	And user submits
	And user selects latest document
	And user submits items:
   | Barcode |
   | 1018    |
   | 1018    |
   | 3468    |
   | 3468    |
	Then items with quantities are added for item grouping: 
   | ExpectedQuantity | ExpectedBarcode |
   | 4                | 1018            |
   | 2                | 3468            |
    
@ignore
@TC176932
Scenario: Code quantity check in write-off with item grouping setting
    Given item grouping is on
	When user selects write-off
    And user presses add operation button
	And user enters document Write-off123
	And user submits
	And user selects latest document
	And user submits items:
   | Barcode |
   | 1018   |
   | 1018   |
   | 1018   |
   | 1018   |
   | 3468   |
   | 3468   |
	Then items with quantities are added for item grouping:  
   | ExpectedQuantity | ExpectedBarcode |
   | 4                | 1018            |
   | 2                | 3468            |
   
#need quantity setting to be turned on
@ignore
@TC176933	
Scenario Outline: Stockadding adding item with quantity
    When user selects stockadding
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user enters item '<Barcode>'
    And user enters quantity <Quantity>
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <Barcode> with quantity <Quantity> is added successfuly
    Examples:
    | Number    | Barcode | Quantity |
    | Adding123 | 1       | 22       |
    
#need quantity setting to be turned on
@ignore
@TC176934
Scenario Outline: Stocktaking adding item with quantity
    When user selects stocktaking
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user enters item '<Barcode>'
    And user enters quantity <Quantity>
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <Barcode> with quantity <Quantity> is added successfuly
    Examples:
    | Number    | Barcode | Quantity |
    | Adding123 | 1       | 22       |
    
#need quantity setting to be turned on
@ignore
@TC176935
Scenario Outline: Write-off adding item with quantity
    When user selects write-off
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user enters item '<Barcode>'
    And user enters quantity <Quantity>
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <Barcode> with quantity <Quantity> is added successfuly
    Examples:
    | Number    | Barcode | Quantity |
    | Adding123 | 1       | 22       |
    
@ignore
Scenario Outline: Stockadding adding item with numeric barcode setting
	Given numeric barcode is on
    When user selects stockadding
    And user presses add operation button
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '<Barcode>' with numeric keyboard
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <Barcode> with quantity 1 is added successfuly
    Examples:
    | Number    | Barcode |
    | Adding123 | 1       |
    
@ignore
Scenario Outline: Stockadding adding item with last digit discard setting
	Given last digit discard setting is on
    When user selects stockadding
    And user presses add operation button
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '<Barcode>'
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <ExpectedBarcode> with quantity 1 is added successfuly
    Examples:
    | Number    | Barcode | ExpectedBarcode |
    | Adding123 | 11      | 1               |
    
@ignore
Scenario Outline: Stockadding adding item with numeric barcode and last digit discard settings
	Given last digit discard and numeric barcode is on
    When user selects stockadding
    And user presses add operation button
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '<Barcode>' with numeric keyboard
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <ExpectedBarcode> with quantity 1 is added successfuly
    Examples:
    | Number    | Barcode | ExpectedBarcode |
    | Adding123 | 11      | 1               |
    
@ignore
Scenario Outline: Stocktaking adding item with numeric barcode setting
	Given numeric barcode is on
    When user selects stocktaking
    And user presses add operation button
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '<Barcode>' with numeric keyboard
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <Barcode> with quantity 1 is added successfuly
    Examples:
    | Number    | Barcode |
    | Adding123 | 1       |
    
@ignore
Scenario Outline: Stocktaking adding item with last digit discard setting
	Given last digit discard setting is on
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
    And item <ExpectedBarcode> with quantity 1 is added successfuly
    Examples:
    | Number    | Barcode | ExpectedBarcode |
    | Adding123 | 11      | 1               |
    
@ignore
Scenario Outline: Stocktaking adding item with numeric barcode and last digit discard settings
	Given last digit discard and numeric barcode is on
    When user selects stocktaking
    And user presses add operation button
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '<Barcode>' with numeric keyboard
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <ExpectedBarcode> with quantity 1 is added successfuly
    Examples:
    | Number    | Barcode | ExpectedBarcode |
    | Adding123 | 11      | 1               |
    
@ignore
Scenario Outline: Write-off adding item with numeric barcode setting
	Given numeric barcode is on
    When user selects write-off
    And user presses add operation button
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '<Barcode>' with numeric keyboard
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <Barcode> with quantity 1 is added successfuly
    Examples:
    | Number    | Barcode |
    | Adding123 | 1       |
    
@ignore
Scenario Outline: Write-off adding item with last digit discard setting
	Given last digit discard setting is on
    When user selects write-off
    And user presses add operation button
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '<Barcode>'
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <ExpectedBarcode> with quantity 1 is added successfuly
    Examples:
    | Number    | Barcode | ExpectedBarcode |
    | Adding123 | 11      | 1               |
    
@ignore
Scenario Outline: Write-off adding item with numeric barcode and last digit discard settings
	Given last digit discard and numeric barcode is on
    When user selects write-off
    And user presses add operation button
    And user enters document <Number>
    And user submits
    And user selects latest document
    And user presses add button
    And user enters item '<Barcode>' with numeric keyboard
    And user submits
    And user syncs items
    Then items are synced successfully
    And item <ExpectedBarcode> with quantity 1 is added successfuly
    Examples:
    | Number    | Barcode | ExpectedBarcode |
    | Adding123 | 11      | 1               |
    
@ignore
Scenario Outline: Barcode change with good item with numeric barcode setting
	Given numeric barcode is on
    When user selects Barcode change
    And Plus button is pressed
    And Product code <Barcode> is entered and submitted with numeric keyboard
    And user presses change button
    And user enters new <NewBarcode> and document <Number>
    And user presses save
    And user syncs items
    Then BarCode is changed successfuly
    Examples:
    | NewBarcode | Barcode |  Number |
    | 2          | 1       | 22      |