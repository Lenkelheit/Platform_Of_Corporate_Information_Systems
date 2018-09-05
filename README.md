# Platform Of Corporate Information Systems

# Contents
* [Description](#description)
* [Task rules](#task-rules)
  - [Task Requirements](#task-requirements)
  - [Deadlines](#deadlines)
  - [Evaluation](#evaluation)
* [Convention](#convention)
  - [Coding Convention](#coding-convention)
    - [Naming](#naming)

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

#### Naming

|  Object Name     |     Type     |  Notation  | Length | Plural | Prefix  | Suffix | Abbreviation | Char Mask   | Underscores |
|:-----------------|-------------:|-----------:|:-------|:-------|:--------|:-------|:-------------|:------------|:------------|
| Assemblies       |Noun(<Company>.<Component>)| PascalCase | 50 | Y/N | No| No     | No           | [A-z]       | No          |
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
| Events           |ObjName+EventName| PascalCase | 128 | No     | No      | Yes    | Yes          | [A-z]{Changed}| No        |
| Enum type        |Noun(regular) or Nouns(bit fields)|PascalCase|128|Yes|No|No     | No           | [A-z]         | No        |

