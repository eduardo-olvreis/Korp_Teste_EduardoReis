import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { NotaFiscalService } from '../../services/nota-fiscal';
import { ProdutoService } from '../../services/produto';

@Component({
  selector: 'app-nota-fiscal-lista',
  templateUrl: './nota-fiscal-lista.html',
  standalone: false
})
export class NotaFiscalLista implements OnInit {
  notas: any[] = [];
  produtos: any[] = [];

  constructor(
    private notaService: NotaFiscalService,
    private produtoService: ProdutoService,
    private cdRef: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.carregarDados();
  }

  carregarDados() {
    this.produtoService.getProdutos().subscribe(prods => {
      this.produtos = prods;
      this.notaService.getNotas().subscribe(notas => {
        this.notas = notas;
        this.cdRef.detectChanges();
      });
    });
  }

  verDetalhes(nota: any) {
    const detalhesItens = nota.itens.map((i: any) => {
      const produto = this.produtos.find(p => p.id === i.produtoId || p.Id === i.produtoId);
      const nomeProduto = produto ? (produto.descricao || produto.Descricao) : 'Produto não encontrado';
      
      return `- ${nomeProduto} (ID: ${i.produtoId}) | Qtd: ${i.quantidade}`;
    }).join('\n');
    alert(`Detalhes da Nota #${nota.numeroSequencial}\nStatus: ${nota.status}\n\nItens:\n${detalhesItens}`);
  }
}