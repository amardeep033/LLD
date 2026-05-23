//Single Responsibility Principle - a class should have only one reason to change
// if multiple responsibility: Harder testing, Tight coupling, Merge conflicts in teams and Low maintainability

using _8_SRP;

BadUser badUser = new BadUser();
badUser.RegisterUser("bad_dummy1", "bad_dummy2");

GoodUser goodUser = new GoodUser();
badUser.RegisterUser("good_dummy1", "good_dummy2");