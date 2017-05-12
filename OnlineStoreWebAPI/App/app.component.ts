import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    template: `<table>
  <tr>
    <th>First Name</th>
    <th>Last Name</th>
  </tr>
  <tr ng-repeat="user in usersObject">
    <td>{{ user.firstname }}</td>
    <td>{{ user.lastname }}</td>
  </tr>
</table>`
})
export class AppComponent {
    name = '';
}