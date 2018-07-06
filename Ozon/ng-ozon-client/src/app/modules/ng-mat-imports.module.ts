import { NgModule } from '@angular/core';
import { MatCardModule, MatButtonModule, MatFormFieldModule } from '@angular/material';

const materialImports = [
  MatCardModule,
  MatButtonModule,
  MatFormFieldModule
];

@NgModule({
  imports: materialImports,
  exports: materialImports
})
export class NgMatImportsModule { }
