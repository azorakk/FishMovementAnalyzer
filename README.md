# Fish Movement Analyzer

This program is analyzing locomotion raw data obtained from behavior tracking of fish larvae with the ZebraBox system (ViewPoint Life Sciences Inc., Montreal, Canada) and their ViewPoint® Zebralab software data output. The program integrates the raw values of activity (number of movements), distance (traveled in mm) and duration (activity in seconds) categories of different movement sizes (minor movements ranging from 0 to 2.1 mm, small movements from 2.1 to 6.1 mm, and large movements exceeding 6.1 mm) per 10 seconds intervals to total activity, total distance and total duration (all movement sizes) and big activity, big distance and big duration (small and large movements; excludes minor movements) for different time periods for each individual fish larvae (c01, c02,…) creating individual sheets for seconds, minutes, 5 minutes and cycle data. From seconds, over minutes and 5 minutes to cycle data, the sum of values of each categorie is calculated. In Cycle Data, each individual fish larvae is assigned two values for light and dark cycles per category. The light and dark cycle periods are defined as alternating 5 minutes in this program. With the help of this application you can analyze hundred thousands of rows of data in less than two seconds. 

## Installation
For Intalling the software in your computer please download the installers in the Setup folder in this repository.

## Running
After installation, open the application and drag and drop your (.csv, .xlsx) file. The analyzed file will appear in the same path of the original file with `original-file-name_analyzed` in the file name.

## Contribution
This repository is open to contributions from everyone, and we appreciate your interest in improving this project.

### To get started with contributing, follow these steps:

* Fork the repository: Click the "Fork" button on the top-right corner of this page to create your own copy of the repository.
* Clone your fork: Use git clone followed by your fork's URL to download the repository to your local machine.
* Create a new branch: Use git checkout -b feature/your-feature-name to create a new branch for your work.
* Make your changes: Work on your contribution. Whether it's fixing a bug, adding a feature, or improving documentation, every contribution is valuable.
* Commit your changes: Use git commit -m "Your descriptive commit message" to commit your changes.
* Push your changes: Use git push origin feature/your-feature-name to push your changes to your fork.
* Submit a Pull Request (PR): Go back to the original repository on GitHub and click on the "New Pull Request" button. Choose the branch you just pushed and describe your changes.

### Guidelines

Before submitting your Pull Request, make sure to follow these guidelines:

* Code Style: Follow the existing code style of the project.
* Testing: If your contribution involves code changes, ensure that you've added appropriate tests and they pass.
* Documentation: Update the README or any relevant documentation if necessary.
* Be respectful: We welcome constructive criticism and feedback, but please be respectful to everyone involved in the project.

## Help and Support
If you have any questions or need assistance, feel free to open an issue or reach out to me directly.

> **Note:**  Flexible protocol lengths can be accommodated, with the default light:dark cycle set at 5 min:5 min. For adjustments to alternative light:dark cycles, please reach out for further customization.Contirbution
