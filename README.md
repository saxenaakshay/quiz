# quiz
This application is a Quiz based game that provides multiple options with 1 correct answer. For assisting the user/player lifelines are provided which can be used once . Features like timer,time bank,skype integeration to make VoIP call are also included.
____________________________

Use Case Specifications:
----------------------
* **View Scores** 

  Actor: user 
  
  Main Success scenario-Player opens the application and directly view
  the scores.
* **Register as a player**

  Actor: User
  
  Main Success scenario-every new player register’s as a contestant before
  starting with the game.
  
  Post condition-User continues and completes the login process to paly
  the game.
* **Log in**

  Actor: User
  
  Pre Condition-User must be registered.
  
  Main Success scenario-user successfully logs in and continues with the
  game.
  
  Exception Scenario-in case username or password is incorrect user is
  again asked to enter the details.  
* **Take Quiz**

  Actor: User
  
  Pre condition-user must have logged in
  
  Main success scenario-user keeps attempting question one by one and
  keeps on adding prize money to his account.
* **Opting for lifeline**

  Actor:User
  
  Main success scenario-User unable to answer the question on his own goes for one of the available lifelines. Lifeline results in its functionality.
  
  Post Condition-User either answers the question or leaves the game.
* **Choose caller for skype call**

  Actor: User
  
  Pre Condition-User must choose phone a friend lifeline.
  
  Main success scenario-user makes a call to person of his own choice by
  entering his/her skype details. Call can be made only for 30 seconds.
