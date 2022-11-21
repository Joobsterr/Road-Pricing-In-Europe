import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoadPricingComponent } from './road-pricing.component';



describe('RoadPricingComponent', () => {
  let component: RoadPricingComponent;
  let fixture: ComponentFixture<RoadPricingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoadPricingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoadPricingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
