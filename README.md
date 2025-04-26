# X-Search
<p >
    <img src="Media/MainPreview.gif" alt="Main preview" width="600"/>
</p>

X-Search (pronounced "cross search") is a tool for aggregating and decluttering search results from across the Internet.    

X-Search is designed with a few key objectives in mind:
- Focusing searches only on evaluations that still need to be made

- Rapidly eliminating undesirable search results

- Facilitating long-term searches made across multiple sessions

- Easing searches in volatile, high-investment markets (used vehicles, housing, employment, etc.)

- Rocking that sweet, sweet mid-2000s UI.

In X-Search, results are **persistent across sessions.** This is thanks to an additive search process called "pulling." A pull doesn't discard previous search results as is typical for a search engine. Instead, each new query simply returns whichever results aren't already in your workspace. 

## Links
- [Quickstart guide](Quickstart.md)

- [Configuring new domains](Configuring%20new%20domains.md)

## Limitations

- **X-Search is still young.** It is also my first major piece of independent software. Kindly expect and forgive technical issues as the project is refined over time.

- **X-Search is an honest web scraper.** Some domains really don't want that kind of traffic. This leaves them currently inaccessible.
    - Known examples include:
        - Indeed.com
        - Zillow.com

- **X-Search is built on Windows Forms.** This is a rather old UI framework that was familiar to me, but ultimately not the right fit for the program's needs. Please excuse the odd bout of visual flickering and unresponsiveness.

- **X-Search relies on search URLs unique to a given query.** This may prevent pulling on domains that deliver search listings by scripts alone.

- **X-Search currently cannot access pages that would require a login.** This may be added in the future, depending on demand.

## Acknowledgements 

- X-Search uses [Selenium Webdriver](https://www.selenium.dev/) to perform its automated pulling. 

## License
Copyright 2025 Host, All Rights Reserved.