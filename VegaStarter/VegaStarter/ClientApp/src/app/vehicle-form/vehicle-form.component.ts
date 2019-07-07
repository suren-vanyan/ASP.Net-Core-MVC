import { FeatureService } from './../services/feature.service';
import { MakeService } from './../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicle-form',
  templateUrl: './vehicle-form.component.html',
  styleUrls: ['./vehicle-form.component.css']
})
export class VehicleFormComponent implements OnInit {
  makes: any;
  models:any[];
  features:any;
  vehicle:any = {};
  
  constructor(private makeService: MakeService,
              private featureService: FeatureService) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(make => 
       {
            this.makes = make;
            console.log('1',this.makes)
       });

       this.featureService.getFeatures().subscribe(feature=>
        {
               this.features = feature;
               console.log('2',this.features)
        });
  }

  onMakeChange() {
   const selectedMake = this.makes.find(m => m.id === this.vehicle.make);
   this.models = selectedMake ? selectedMake.models : [];
  }
}
