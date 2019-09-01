
import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any;
  models: any;
  features: any;
  vehicle: any = {};

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getMakes().subscribe(makes =>
      this.makes = makes);

    this.vehicleService.getFeatures().subscribe(features =>
      this.features = features);
  }

  onMakeChange() {

    
    const selectedMake = this.makes.find(m => m.id == this.vehicle.make);
    console.log(selectedMake);
    this.models = selectedMake ? selectedMake.models : [];
  }
}
