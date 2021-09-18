$(document).ready(function () {
    load();
});

function load() {
    var busca = ($("#busca").val() || '');
    var pesoMaior = ($("#pesomaior").val() || 0);
    var pesoMenor = ($("#pesoMenor").val() || 0);
    PessoaListaPessoas(busca, pesoMenor, pesoMaior).then(function (data) {
        data.forEach(obj => {
            $('#dataTable').append('' +
                '<tr id="obj-' + obj.id + '">' +
                '<td>' + (obj.nome || '--') + '</td>' +
                '<td>' + (moment(obj.dataNascimento).format('DD/MM/YYYY') || '--') + '</td>' +
                '<td>' + (obj.peso || '--') + '</td>' +
                '<td>' + (obj.cidade.nome || '--') + '</td>' +
                '<td>' + (obj.ativo === true ? 'Ativo' : 'Inativo') + '</td>' +
                '</tr>');
        });
    });
}