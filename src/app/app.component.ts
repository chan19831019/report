import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'report';
  navLinks: any[] = [];

  constructor() {
    for (let i = 4; i <= 16; i++) {
      this.navLinks.push({ path: 'report' + i, label: '報表' + i });
    }
  }
}
