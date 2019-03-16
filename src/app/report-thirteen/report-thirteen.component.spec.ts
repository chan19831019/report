import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportThirteenComponent } from './report-thirteen.component';

describe('ReportThirteenComponent', () => {
  let component: ReportThirteenComponent;
  let fixture: ComponentFixture<ReportThirteenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ReportThirteenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportThirteenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
