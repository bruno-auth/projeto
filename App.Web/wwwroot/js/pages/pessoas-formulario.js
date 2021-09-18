$(document).ready(function () {
    loadCidades();
})

function loadCidades() {
    CidadeListaCidades('').then(function (data) {
        data.forEach(obj => {
            $('#cidadeId').append('<option value="' + obj.id + '">' + obj.nome + '</option>')
        });
        $('#cidadeId').select2();
    });
}

function salvar() {
    let obj = {
        nome: ($("[name='nome']").val() || ''),
        dataNascimento: ($("[name='dataNascimento']").val() || ''),
        peso: ($("[name='peso']").val() || ''),
        ativo: ($("[name='ativo']").val() || ''),
        cidadeId: ($("[name='cidadeId']").val() || ''),
    };
    PessoaSalvar(obj).then(function () {
        window.location.href = '/pessoas';
    }, function (err) {
        alert(err);
    });
}