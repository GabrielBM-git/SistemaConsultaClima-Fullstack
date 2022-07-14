//-------------------------------------------------------------------------------------------------

import { Component } from '@angular/core';

import { FormGroup, FormBuilder, Validators } from '@angular/forms';

//-------------------------------------------------------------------------------------------------

import { AjaxService } from './services/ajax.service';

//-------------------------------------------------------------------------------------------------

import { Cidade } from './models/cidade';

import { PrevisaoClima } from './models/previsaoClima';

//-------------------------------------------------------------------------------------------------

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

//-------------------------------------------------------------------------------------------------

export class AppComponent {

  //-----------------------------------------------------------------------------------------------

  public title = 'Clima Tempo - Simples';

  public previsaoClima_Minimas: PrevisaoClima[] = [];
  public previsaoClima_Maximas: PrevisaoClima[] = [];
    
  public previsaoClima_Cidades: Cidade[] = [];

  public previsaoClima_7Dias: PrevisaoClima[] | undefined;

  public modelForm: FormGroup;

  public cidade: string = 'São Paulo';

  //-----------------------------------------------------------------------------------------------

  constructor(private ajaxService: AjaxService, private fb: FormBuilder) {

    // console.log('Loading...');
    
    //---------------------------------------------------------------------------------------------

    this.ajaxService.get_Minimas().subscribe(
      
      (result: any) => {
        // console.log(result);
        this.previsaoClima_Minimas = result;
      },

      (error: any) => {
        console.error(error);
      }
    );

    //---------------------------------------------------------------------------------------------

    this.ajaxService.get_Maximas().subscribe(
      
      (result: any) => {
        // console.log(result);
        this.previsaoClima_Maximas = result;
      },

      (error: any) => {
        console.error(error);
      }
    );

    //---------------------------------------------------------------------------------------------

    this.ajaxService.get_Cidades().subscribe(
      
      (result: any) => {
        // console.log(result);
        this.previsaoClima_Cidades = result;
      },

      (error: any) => {
        console.error(error);
      }
    );

    //---------------------------------------------------------------------------------------------

    this.modelForm = this.fb.group({
      cidade: [ '', Validators.required ]
    });

    //---------------------------------------------------------------------------------------------

    this.Post_Previsao7dias();

    //---------------------------------------------------------------------------------------------
  }

  //-----------------------------------------------------------------------------------------------

  Buscar() {

    //---------------------------------------------------------------------------------------------

    var valido: Boolean = false;

    //---------------------------------------------------------------------------------------------

    var cidade_: string = ((this.modelForm.value.cidade) ? this.modelForm.value.cidade : this.cidade);
    
    this.previsaoClima_Cidades.find(cidade => { 
      if(cidade_ === cidade.nome || cidade_ === cidade.nome.toLowerCase() || cidade_ === cidade.nome.toUpperCase()) {
        valido = true;
        this.cidade = cidade.nome;
      }
    });

    // console.log(this.cidade)

    //---------------------------------------------------------------------------------------------

    this.modelForm.value.cidade = '';
    this.modelForm.patchValue(this.modelForm.value);

    //---------------------------------------------------------------------------------------------

    if (valido)
      this.Post_Previsao7dias();

    //---------------------------------------------------------------------------------------------
  }

  //-----------------------------------------------------------------------------------------------
  
  onGroupSelect(event: any) {

    this.cidade = event.value;

    (document.getElementById('select_group') as HTMLSelectElement).selectedIndex = 0;

    this.Buscar();
  }

  //-----------------------------------------------------------------------------------------------
  
  Post_Previsao7dias() {
    
    const service$ = this.ajaxService.post_7Dias(this.cidade);

      service$.subscribe(

        (result: any) => {
          // console.log(result);
          this.previsaoClima_7Dias = result;
          
          this.Configuration();
        },

        (error: any) => {
          console.error(error);
        }
      ); 
  }
  
  //-----------------------------------------------------------------------------------------------

  Configuration() {

    if (this.previsaoClima_7Dias) {
      for(var i = 0; i < this.previsaoClima_7Dias.length; i++)
        this.Config(this.previsaoClima_7Dias[i]);
    }
    
  }

  //-----------------------------------------------------------------------------------------------
  
  Config(objeto: PrevisaoClima) {

    if (objeto.dataPrevisao) {

      objeto.dataPrevisao = new Date(objeto.dataPrevisao);

      objeto.dataPrevisao_ = (((objeto.dataPrevisao.getDate() < 9) ? '0' : '') + objeto.dataPrevisao.getDate() + '/' + 
                              (((objeto.dataPrevisao.getMonth() + 1) < 9) ? '0' : '') + (objeto.dataPrevisao.getMonth() + 1) + '/' + 
                                objeto.dataPrevisao.getFullYear());

      var semana = ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"];

      objeto.dataPrevisao_Semana = semana[objeto.dataPrevisao.getDay()];
    }
    
  }

  //-----------------------------------------------------------------------------------------------
}

//-------------------------------------------------------------------------------------------------