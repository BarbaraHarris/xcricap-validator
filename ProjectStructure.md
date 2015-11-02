# Introduction #

The project is split at the top level into two main folders: [lib](http://code.google.com/p/xcricap-validator/source/browse/#hg%2Flib) and [src](http://code.google.com/p/xcricap-validator/source/browse/#hg%2Fsrc).  The `lib` folder is a library folder containing resources that are used by the project, with the `src` folder containing the actual project source.

The `src` folder contains the project source which is split down into two Visual Studio 2010 projects: [XCRI.Validation](http://code.google.com/p/xcricap-validator/source/browse/#hg%2Fsrc%2FXCRI.Validation) and [TestProject](http://code.google.com/p/xcricap-validator/source/browse/#hg%2Fsrc%2FTestProject).

# XCRI.Validation #

XCRI.Validation contains the actual validation project's core code and is used to actually validate a feed.

# TestProject #

TestProject contains a Visual Studio project with over 650 tests of the project.  When submitting any changesets to the project, please ensure that these are run (and pass!) to try and ensure project quality.  Equally, if you are adding code to the project, please try and add tests as appropriate.