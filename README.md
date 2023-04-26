# Inspector

A C# terminal application allowing users to search for various social network sites based on a specified username.

# Usage

$ git clone https://github.com/jeremyolu/Inspector.git

Open Inspector.sln and run application within your desired IDE.

![image](https://user-images.githubusercontent.com/32248981/187234156-493dddcb-8986-4b55-bb33-df5abee93e9d.png)

# Implementation

The terminal app has been implemented in a way that is simple and easy to use. A list of predefined social network links are used to search for accounts based on a username. In order to determine for sure if a account exists with that username, a GET request is made to the various social network links. If a 200 status code is returned then the account is returned in the results.

# Issues

It has been noticed that some social networking sites usually do not return 200 response codes for found user accounts, or that user accounts that don't exist return a 200 status code which results in a false positive, therefore potentially affecting the results of a search.

# Contribute

Please feel free to make changes to the implementation and submit a pull request if you believe implementation can be added or improved.
# Disclaimer

This terminal app was developed for development and research purposes only. I do not intend to carry out any unethnical practices. This was soley for the purpose of research. Please do not use this for bad practices.
