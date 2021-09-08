<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/HenkoR/HLess">
    <img src="images/logo.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">Headless CMS</h3>

  <p align="center">
    HLess is a Headless CMS built with .Net 5 
    <br />
    <a href="https://github.com/HenkoR/HLess"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/HenkoR/HLess">View Demo</a>
    ·
    <a href="https://github.com/HenkoR/HLess/issues">Report Bug</a>
    ·
    <a href="https://github.com/HenkoR/HLess/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://example.com)

### Built With

* [.Net 5](https://dotnet.microsoft.com/download/dotnet/5.0)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [MSSql](https://www.microsoft.com/en-us/sql-server/)
* [Redis](https://redis.io/)
* [JSON](https://www.json.org/json-en.html)
* [Dapper](https://dapper-tutorial.net/)

### Solution Architecture

- Hless.Common
- Hless.Test
- Hless.AdminWeb
- Hless.Api
    - Hless.Data
        - Hless.Data.Mssql
        - Hless.Data.InMemory (Used for local testing and automated testing)
    - Hless.Cache
        - Hless.Cache.Redis

<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

* [.Net 5](https://dotnet.microsoft.com/download)

  
### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/HenkoR/HLess.git
   ```
2. Build Solution to restore any packages
   ```sh
   dotnet build ./src/HlessApi.sln
   ```



<!-- USAGE EXAMPLES -->
## Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.


<!-- ROADMAP -->
## Roadmap

See the [open issues](https://github.com/HenkoR/HLess/issues) for a list of proposed features (and known issues).



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## Coding guidelines and standards

Some good coding standards and best practice guidelines that we try and adhere to are listed below.
- [Rest API Guidelines](https://github.com/Microsoft/api-guidelines/blob/master/Guidelines.md)

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

Henko Rabie - [@henkorabie](https://twitter.com/henkorabie) - henkorabie99@gmail.com

Project Link: [https://github.com/HenkoR/HLess](https://github.com/HenkoR/HLess)



<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

* []()
* []()
* []()





<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/HenkoR/repo.svg?style=for-the-badge
[contributors-url]: https://github.com/HenkoR/HLess/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/HenkoR/repo.svg?style=for-the-badge
[forks-url]: https://github.com/HenkoR/HLess/network/members
[stars-shield]: https://img.shields.io/github/stars/HenkoR/repo.svg?style=for-the-badge
[stars-url]: https://github.com/HenkoR/HLess/stargazers
[issues-shield]: https://img.shields.io/github/issues/HenkoR/repo.svg?style=for-the-badge
[issues-url]: https://github.com/HenkoR/HLess/issues
[license-shield]: https://img.shields.io/github/license/HenkoR/repo.svg?style=for-the-badge
[license-url]: https://github.com/HenkoR/HLess/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/HenkoR