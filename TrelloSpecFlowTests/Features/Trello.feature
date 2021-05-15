Feature: Trello
    Kanban-based app for project and time management
      
@mytag
Scenario: Create new list
    Given the name of list is "Mobile app"
    And the board id is "5dd85a7f8f92ff62c8a4fcd8"
    When the function are executed
    Then the board is created    
    
@mytag
Scenario: Get boards with particular fields
    Given the required field is "name"
    When the function to get are executed
    Then the first name in the list is not null
#    Then the first name in the list is null
    
    
@mytag
Scenario: Update existing list
    Given the list id is "60981703c97b4a7aa03edd9f"
    And the desired list name is "Exams preparation 2021"
    When the function to update are executed
    Then the new list name is right 
    

@mytag
Scenario: Create new card inside existing list
    Given the list id is "60981703c97b4a7aa03edd9f"
    And the desired card name is "Pay attention to graphics lab"
    When the function to create card are executed
    Then the new card name is right