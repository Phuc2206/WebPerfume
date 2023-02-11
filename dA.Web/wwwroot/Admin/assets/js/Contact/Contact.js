$("#btnSaveContact").on("click", function (ev) {
	ev.preventDefault();
	let FullName = document.querySelector('#FullName').value;
	let Email = document.querySelector('#Email').value;
	if (FullName == "" || Email == "") {
		Swal.fire({
			icon: 'error',
			title: 'Oops...',
			text: 'Vui lòng nhập đủ thông tin!!!!'
		});
	}
	else {
		var form = $("#ContactForm");
		var data = new FormData(form[0]);
		$.ajax({
			url: "/Contact/Create",
			data: data,
			dataType: 'json',
			type: "POST",
			processData: false,
			contentType: false,
			success: function (res) {
				if (res == true) {
					$('#Contact_modal').modal('hide');
					$("#ContactForm")[0].reset();
					Swal.fire({
						position: 'center',
						icon: 'success',
						title: 'Thao tác thành công',
						showConfirmButton: false,
						timer: 1500
					})
					loadData();
				}
				else {
					Swal.fire({
						position: 'center',
						icon: 'error',
						title: 'Thao tác thất bại',
						showConfirmButton: false,
						timer: 1500
					})
					loadData();
				}
			}
		});
	}
})

// btn huy modal
$("#btnClose").on("click", function () {
	$("#Id").val(null);
	$().modal('hide')
	$()[0].reset();
});