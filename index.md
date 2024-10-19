# Mastering The C# Programming Language course Exercises

These hands-on exercises are designed to support training content.

To complete these exercises, you'll need a Visual Studio Code (VS Code) and the C# Extension to complete the exercises. You can download VS Code at [https://code.visualstudio.com/](https://code.visualstudio.com/).

{% assign labs = site.pages | where_exp:"page", "page.url contains '/modules'" %}
| Exercises |
| ------- | 
{% for activity in labs  %}| [{{ activity.lab.title }}]({{ site.github.url }}{{ activity.url }}) |
{% endfor %}