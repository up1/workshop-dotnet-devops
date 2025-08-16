*** Settings ***
Library    SeleniumLibrary
Test Teardown    Close All Browsers

*** Variables ***
${URL}    http://web:8080
${SELENIUM_URL}    http://selenium-hub:4444/wd/hub

*** Test Cases ***
Check Welcome Page
    Open Browser    ${URL}    chrome   remote_url=${SELENIUM_URL}
    Maximize Browser Window
    Wait Until Element Contains    xpath=/html/body/div/main/div/h1    Welcome

Check Forecast Data
    Open Browser    ${URL}    chrome   remote_url=${SELENIUM_URL}
    Maximize Browser Window
    Wait Until Element Contains    xpath=//div/div/ul/li[2]/a    Weather Forecast
    Click Element    xpath=//div/div/ul/li[2]/a
    Wait Until Element Contains    xpath=/html/body/div/main/div/h1    Weather Forecast