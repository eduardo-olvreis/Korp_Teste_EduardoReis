import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { NotaFiscalService } from '../../services/nota-fiscal';
import { ProdutoService } from '../../services/produto';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-nota-fiscal-lista',
  templateUrl: './nota-fiscal-lista.html',
  standalone: false
})
export class NotaFiscalLista implements OnInit {
  notas: any[] = [];
  produtos: any[] = [];
  processandoId: number | null = null;

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

  fecharNota(nota: any) {
    if (confirm(`Deseja imprimir e fechar a nota #${nota.numeroSequencial}?`)) {
      this.processandoId = nota.id;
      this.notaService.fecharNota(nota.id)
        .pipe(
          finalize(() => {
            this.processandoId = null;
            this.cdRef.detectChanges();
          })
        )
        .subscribe({
          next: () => {
            alert('Nota impressa e fechada com sucesso!');
            this.carregarDados();
          },
          error: (err) => {
            console.error('Log do erro:', err);
            
            if (err.status === 400) {
              alert('Não foi possível finalizar: Verifique se há saldo disponível no estoque para todos os itens.');
            } else if (err.status === 0 || err.status === 500) {
              alert('Falha de comunicação: O serviço de integração está temporariamente indisponível.');
            } else {
              alert('Ocorreu um erro inesperado ao processar a impressão da nota.');
            }
          }
        });
    }
  }
}