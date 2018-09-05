# Platform Of Corporate Information Systems

# Contents
* [Description](#description)
* [Task rules](#task-rules)
  - [Task Requirements](#task-requirements)
  - [Deadlines](#deadlines)
  - [Evaluation](#evaluation)
* [Convention](#convention)
  - [Coding Convention](#coding-convention)
    - [General](#general)
    - [Naming](#naming)
    - [Formating](#formating)

## Description

**Team number:** 1

**Team name:** The demons of .Net

### Team

| <sub><b>SvyatoslavFedynyak</b></sub>| <sub><b>Lenkelheit</b></sub>|<sub><b>vasil98</b></sub> | <sub><b>iamprovidence</b></sub>|
| :---: | :---: | :---: | :---: |
| [<img src="https://avatars2.githubusercontent.com/u/36925520?s=400&v=4" width="100px;"/>](https://github.com/SvyatoslavFedynyak) | [<img src="https://avatars3.githubusercontent.com/u/38116562?s=400&v=4" width="100px;"/>](https://github.com/Lenkelheit) | [<img src="https://avatars3.githubusercontent.com/u/22750664?s=400&v=4" width="100px;"/>](https://github.com/vasil98)| [<img src="https://avatars3.githubusercontent.com/u/24938726?s=400&v=4" width="100px;"/>](https://github.com/iamprovidence) |

## Task rules

### Task Requirements

* use StyleCop's recommended coding styles
* code covered with Unit-tests
* all public code-blocks have XML-documentation

### Deadlines

*	Teaming up – 14.09.2018
*	Task1. C#  – 20.09.2018
*	Task2. WPF Shapes – 10.10.2018
*	Task3. WPF Services – 1.11.2018
*	Task4. ADO .Net – 22.11.2018
*	Task5. Entity + WPF  - 14.12.2018

### Evaluation

* Tasks — 85
  - Teaming up – 5
  -	Task1. C#  – 10
  -	Task2. WPF Shapes – 20
  -	Task3. WPF Services – 20
  -	Task4. ADO .Net – 10
  -	Task5. Entity + WPF  - 20
 

There should be commits and projects. Task should be done before deadline — 40 % of mark.

All requirements are satisfied — 50% of mark.

Task protection — 10% of mark. Should be on the next lesson after deadline.

* Tests — 15
  - Test1 — 5
  - Test2 — 5
  - Test3 — 5

## Convention

### Coding Convention

### General

- Cycles
  - use ++i not i++
- Variable 
  - do not use *magic numbers*(*magic strings*), better use constants
- Fields
  - do not use public fields
- Properties
  - use read-only properties
  - do no use write-one properties, better use method
  - if properties return field, it should has the same name
- Methods
  - one method = one action
  - method's body shoud be in 25-50 lines range
  - private methods for inner complex instructions
  - event methods should start with On- preffix
- Events
  - **Two arguments**:
    - sender, object — object that has generated event
    - e — instance of EventArgs, contain event data
- Exception Handling
  - do not ignore cathed exception
    - some special exception can be ignored : ThreadAbortException
  - do hide errors from user, if can not handle exception show user a message
  - log exception in files with all details (type, time, method's name, class' name etc)
  - do not catch all exception, only specific ones
- Files
  - Each class in seperate file
  - File's name same as class' name
- Comments
  - every *public* block of code should has XML-documentation
  - every *private* block of code should has comments
  - avoid block of comments 
  - full sentence for comments
  - comments should be up in date
  - comments should be clear and understandable
  - single-line comments preffered over end-line ones
  - use comments in complex block of codes

#### Naming

- "What?" not "How?"
- Make a sense
- Avoid redundency
```diff
- List.ListItem
+ List.Item
```
- Variable 
  - ‘i’, ‘j’, ’k’, ’l’, ’m’, ’n’  - cycles 
  - ‘x’, ‘y’, ‘z‘ -  coordinate
  - ‘r’, ‘g’, ‘b’  - colors
  - ‘e’  - events
  - ‘ex’  - exceptions

|  Object Name     |     Type     |  Notation  | Length | Plural | Prefix  | Suffix | Abbreviation | Char Mask   | Underscores |
|:-----------------|-------------:|-----------:|:-------|:-------|:--------|:-------|:-------------|:------------|:------------|
| Assemblies       |Nouns(Company.Component)   | PascalCase | 50 | Y/N | No| No     | No           | [A-z]       | No          |
| Namespace        |Noun          | PascalCase |    50  | Y/N    | No      | No     | No           | [A-z]       | No          |
| Interface        |Noun or Nouns | PascalCase |    128 | No     | Yes     | No     | No           | {**I**}[A-z]| No          |
| Struct           |Noun or Nouns | PascalCase |    128 | No     | No      | Yes    | No           | [A-z][0-9]  | No          |
| Class            |Noun or Nouns | PascalCase |    128 | No     | No      | Yes    | No           | [A-z][0-9]  | No          |
| Constructor      |Same as class | PascalCase |    128 | No     | No      | Yes    | No           | [A-z][0-9]  | No          |
| Event Class      |Nouns         | PascalCase |    128 | No     | No      | Yes    | No           | [A-z][0-9]{EventArgs}| No |
| Attribute class  |Nouns         | PascalCase |    128 | No     | No      | Yes    | No           | [A-z][0-9]{Attribute}| No |
| Method           |Verbs         | PascalCase |    128 | Yes    | No      | No     | No           | [A-z][0-9]  | No          |
| Method arguments |Depend on type| camelCase  |    128 | Yes    | No      | No     | Yes          | [A-z][0-9]  | No          |
| Generic argument |Noun          | PascalCase |    50  | Yes    | No      | No     | Yes  |{**T**}[A-z][0-9]{Key,EventArgs}|No|
| Local variables  |Noun or Nouns | camelCase  |    50  | Yes    | No      | No     | Yes          | [A-z][0-9]  | No          |
| Constants name   |Noun or Nouns | UpperCase  |    50  | No     | No      | No     | No           | [A-z][0-9]  | No          |
| Field            |Noun or Nouns | camelCase  |    50  | Yes    | No      | No     | Yes          | [A-z][0-9]  | Yes         |
| Boolean Fields   |Noun or Nouns | camelCase  |    50  | Yes    | Yes     | No     | Yes    | {is,can,has,does+}[A-z][0-9]|Yes|
| Properties       |Same as field | PascalCase |    50  | Yes    | No      | No     | Yes          | [A-z][0-9]  | No          |
| Delegate         |Nouns         | PascalCase |    128 | No     | No      | Yes    | Yes          | [A-z]{EventHandler}| No   |
| Events           |Nouns         | PascalCase | 128    | No     | No      | Yes    | Yes          | [A-z]{Changed}| No        |
| Enum type        |Noun(regular) or Nouns(bit fields)|PascalCase|128|Yes|No|No     | No           | [A-z]         | No        |
| GUI              |Noun or Nouns |HungarianNotation|50 | Yes    | Yes     | Yes    | Yes          | [A-z]         | No        |
| GUI events       |ObjName + _ + EventName |PascalCase |128| No | No      | Yes    | Yes          | [A-z]{Changed}| Yes       |

#### Formating

* Padding
  - every block of code should has padding depending on outer block
  - padding should be done with tabulation
  - use empty lines to divide logic
  - constanst and enums should be align on their types, names, operators etc
  ```diff
  	  public const int DBVERSION        = 4;
  		public const int TINYINT_OWERFLOW = 8115;
  		public const int TRIGGER_EXCEPT   = 50000;

  		public enum StatusMode
  		{
  	    		Planned  = 1,
  	    		Active   = 2,
  	    		InActive = 4,
  	    		All      = 7
  		};

  ```
  - whitespaces after and before operators
  ```diff
  -isDisposing=false;
  +isDisposing = false;
  ```
  - long boolean statements should be divided by &&, || operators or incapsulated in variable or method
* code line length should be less than 80 symbols
* every block of code (cycles, condition statements etc) should has curve brackets
  - exceps shor one (80 symbols)
* vertical brackets allignment
```diff
- if (...){
-}
+ if (...)
+{
+}
```
* one line = one command 

