import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportNineComponent } from './report-nine.component';

describe('ReportNineComponent', () => {
  let component: ReportNineComponent;
  let fixture: ComponentFixture<ReportNineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportNineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportNineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
