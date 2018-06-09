# HPNC Umbraco Site
This project was created as part of the Nerdery's 24 Hour coding challenge and has been continued by several members of the Coding Temple Team. The project's goal is to replace Hyde Park Neighborhood Club's current website with a flexible, admin-friendly, and modern-looking website, which is fast, mobile-responsive, and reliable. The project utilizes [Umbraco](https://umbraco.com/), a .Net CMS, to allow HPNC administrators to be able to edit, create, and delete pages as their own programs and initiatives develop. 

## Getting Started

### Prerequisites

* Visual Studio 2017

### Installing

## Troubleshooting
* If you receive error about missing index, delete all files in \HPNC\HPNC Website\App_Data\TEMP\ExamineIndexes\Internal\Index 

* If you receive an error regarding Archetype while building, download Archetype (https://our.umbraco.org/projects/backoffice-extensions/archetype/)  yourself. Then using file explorer, just copy and paste the archetype.dll file into the HPNC project. (HPNC Project folder >  HPNCUmbraco folder > bin).

* If you receive a 404 on most images in the project, take a look at the route in Chrome developer tools. To accommodate the format by which umbraco saves the file url, we created a helper function which adds the root folder to the url. That root varies depending on whether the project is being built in production or local development. That root depends on this line in the web.config file.

``` <add key="BaseURL" value="http://localhost/" />```

Change the BaseURL value to match your own localhost root, such as `value="http://localhost:8800/"`.

## Deployment
This project is currently deployed through the Azure Portal.

## Built With

* [.Net Framework 4.5.2] - Our framework
* [Umbraco](https://umbraco.com/) - An ASP.Net content management system
* [Archetype](https://our.umbraco.org/projects/backoffice-extensions/archetype/) - An Umbraco Plugin that enables nested complex properties

## Version Control
Version control has been a challenge throughout the process. Mainly because when changes are made through the Umbraco back office, some of those changes may not be managed by git, because they are applied to a database - not to code. (Much of Umbraco's content is stored in a SQL database.) So the way we're managing this issue is pointing all our environments (local and staging) toward an Azure DB. This gives us some redundancy with the DB but it could also cause problems with syncing these two enviroments. 

Also, at times, we may have HPNC staff or designers working in the staging site through the back office, making changes that may impact our local code. 

The best (but imperfect) solution we've developed so far for this issue is to occasionally FTP from the staging site, replace the local project with the FTP files, and then push those changes to master. Then the git Master, the Staging, and up-to-date local environments are all working from the same code and DB.

## Contributing

All changes to this project are through pull requests with requested review.

## Acknowledgments

* The Nerdery
* Clayton Halaska
* Daniela Akers
* Nick Gardner
* Anthony Jarina
* Robert Mazza
* Prerak Desai
* Erica Wasilenko
* Ripal Patel
* Joe Johnson
