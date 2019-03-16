import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportTwelveComponent } from './report-twelve.component';

describe('ReportTwelveComponent', () => {
  let component: ReportTwelveComponent;
  let fixture: ComponentFixture<ReportTwelveComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportTwelveComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportTwelveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
