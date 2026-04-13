import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NotaFiscal } from '../models/nota-fiscal.model';

@Injectable({ providedIn: 'root' })
export class NotaFiscalService {
  private apiUrl = 'http://localhost:5144/api/NotaFiscal'; 
  constructor(private http: HttpClient) { }

  getNotas(): Observable<NotaFiscal[]> {
    return this.http.get<NotaFiscal[]>(this.apiUrl);
  }

  criarNota(nota: NotaFiscal): Observable<NotaFiscal> {
    return this.http.post<NotaFiscal>(this.apiUrl, nota);
  }

  fecharNota(id: number): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}/fechar`, {});
  }
}