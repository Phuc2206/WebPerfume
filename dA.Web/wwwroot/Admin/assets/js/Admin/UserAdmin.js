$("#AddUser").on("click", function () {
	const imageUploadContainer = document.querySelector(".image-upload-container");
	const imageUploadButton = document.querySelector(".image-upload-button");
	imageUploadContainer.addEventListener('click', () => {
		imageUploadButton.click();
	});
	imageUploadButton.addEventListener('change', () => {
		if (imageUploadButton.files && imageUploadButton.files[0]) {
			var reader = new FileReader();
			reader.onload = function (e) {
				let imageTag = document.getElementById('Avatar');
				imageTag.src = e.target.result;
				imageUploadContainer.insertAdjacentElement('beforeend', imageTag);
			}
			reader.readAsDataURL(imageUploadButton.files[0]);
		}
	});
	//$(document).on('click', ".submit-button", () => {
	//	$(".them-moi-form").submit();
	//});
});


// btn huy modal
$("#btnClose").on("click", function () {
	$("#Id").val(null);
	$('#UserForm_modal').modal('hide')
	$("#Avatar").attr("src", "url");
	$("#UserForm")[0].reset();
});

// btn lưu modal
$("#btnSaveTrademarks").on("click", function (ev) {
	ev.preventDefault();
	var form = $("#UserForm");

	
	let Email = document.querySelector('#Email').value;
	let Name = document.querySelector('#FullName').value;
	let Username = document.querySelector('#Username').value;
	let Phonenumber = document.querySelector('#Phonenumber').value;
	let Password = document.querySelector('#Password').value;



	if (Email == "" || Name == "" || Phonenumber == "" || Username == "" || Password == "") {
		Swal.fire({
			icon: 'error',
			title: 'Oops...',
			text: 'Vui Lòng nhập đầy đủ thông tin'
		});
	} else {
		var data = new FormData(form[0]);
		$.ajax({
			url: "/Admin/UserAdmin/AddUser",
			data: data,
			dataType: 'json',
			type: "POST",
			processData: false,
			contentType: false,
			success: function (res) {
				if (res == true) {
					$('#UserForm_modal').modal('hide');
					$("#Avatar").attr("src", "");
					$("#UserForm")[0].reset();
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

// Lấy dử liệu lên 
function loadData(_page) {
	$.ajax({
		type: 'GET',
		url: '/Admin/UserAdmin/ListUser?page=' + _page,
		success: function (res) {
			$('tbody').html('');
			render(res.data);
			var currentPage = res.currentPage;
			var pageSize = res.perPage;
			var totalRow = res.pageCount;
			var arrPager = getPager(currentPage, pageSize, totalRow);
			arrPager = arrPager.map(function (item) {
				var eleClass = "";
				if (item.isCurrentPage) {
					eleClass = "active";
				}
				return (
					'<li><a class="border-radius-0 btn btn-primary waves-effect waves-light ' +
					eleClass +
					'" data-page="' +
					item.page +
					'" href="#">' +
					item.text +
					"</a></li>"
				);
			});
			var pagination = $(".pagination");
			pagination.html(arrPager.join(""));
		}
	}).then(function () {
		$("a[data-page]").click(function (ev) {
			ev.preventDefault();
			page = $(ev.currentTarget).attr("data-page");
			loadData(page);
		});
	});
};
function render(data) {
	return data.forEach(function (res, index) {
		var tr = $('<tr>').appendTo('tbody');
		var td = `		<td>${res.id}</td>
						<td >${res.username}</td>
						<td>${res.fullname}</td>
						<td><img src="/Images/Admin/${res.avatar}" class="img-fluid rounded-circle img-responsive" style="height: 50px; width: 50px; right: 10px;"></td>
						${SoSanh(res.isSuper, res.id)}
						<td data-id="${res.id}">
							<div class="btn-group text-center" role="group">
							<a href="#" class="btn btn-sm btn-outline-secondary js-delete" data-toggle="tooltip" data-placement="top" title="Xóa tài khoản này" data-id="${res.id}">
							<i class="fas fa-trash-alt"></i></a>
							</div>
						</td>`
		$(td).appendTo(tr);
	});
};
/**/
window.addEventListener('load', () => {
	loadData();
});

const SoSanh = (data, id) => {
	if (data == true) {
		return `<td class="text-center" data-id=${id} ><a href="#" data-toggle="tooltip" data-placement="top" title="Thay đổi quyền" class="js-edit-role"><i class="fa fa-2x fa-check-square text-success"></i></a></td>`
	}
	return `<td class="text-center" data-id=${id}><a href="#" data-toggle="tooltip" data-placement="top" title="Thay đổi quyền" class="js-edit-role"><i class="fa fa-2x fa-times text-gray"></i></a></td>`
}

// js xoa
$(document).on("click", ".js-delete", function (ev) {
	ev.preventDefault();
	var id = $(ev.currentTarget).closest("td").attr("data-id");
	Swal.fire({
		title: 'Bạn có chắc xóa không?',
		text: "Bạn sẽ không thể hoàn nguyên điều này",
		icon: 'warning',
		showCancelButton: true,
		confirmButtonColor: '#3085d6',
		cancelButtonColor: '#d33',
		confirmButtonText: 'Xóa',
		cancelButtonText: 'Hủy'
	}).then((result) => {
		if (result.isConfirmed) {
			$.ajax({
				type: "DELETE",
				url: "/Admin/UserAdmin/Delete",
				data: { id: id },
				success: function (res) {
					if (res == true) {
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
						loadData()
					}
				},
				error: function (res) {
					Swal.fire({
						position: 'center',
						icon: 'error',
						title: 'tài khoản này không đủ quyền để thực thi lệnh',
						showConfirmButton: false,
						timer: 1500
					})
				}

			})
		}
	});
});

$(document).on("click", ".js-edit-role", function (ev) {
	ev.preventDefault();
	var id = $(ev.currentTarget).closest("td").attr("data-id");
	$.ajax({
		url: "/Admin/UserAdmin/Edit",
		data: { id: id },
		dataType: 'json',
		type: "POST",
		success: function (res) {
			if (res == true) {
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
				loadData()
			}
		},
		error: function (res) {
			Swal.fire({
				position: 'center',
				icon: 'error',
				title: 'tài khoản này không đủ quyền để thực thi lệnh',
				showConfirmButton: false,
				timer: 1500
			})
		}
	});
});




// Function phân trang js
function getPager(currentPage, pageSize, totalRow) {
	const ON_EACH_SIDE = 1;
	var arrPager = [];
	var totalPage = Math.ceil(totalRow / pageSize);

	currentPage = parseInt(currentPage);
	if (totalPage == 0) {
		return arrPager;
	}
	else {
		// current page
		arrPager.push({
			isCurrentPage: true,
			text: currentPage,
			page: currentPage,
		});
		// after current page
		var i = 1;
		while (currentPage + i <= totalPage) {
			arrPager.push({
				isCurrentPage: false,
				text: currentPage + i,
				page: currentPage + i,
			});
			i++;
			if (i > ON_EACH_SIDE) break;
		}
		if (currentPage + ON_EACH_SIDE < totalPage) {
			arrPager.push({
				isCurrentPage: false,
				text: "&rArr;",
				page: totalPage,
			});
		}

		// before current page
		i = 1;
		var tmp = currentPage;
		while (tmp > 1) {
			arrPager.unshift({
				isCurrentPage: false,
				text: currentPage - i,
				page: currentPage - i,
			});
			i++;
			tmp--;
			if (i > ON_EACH_SIDE) break;
		}
		if (currentPage - ON_EACH_SIDE > 1) {
			arrPager.unshift({
				isCurrentPage: false,
				text: "&lArr;",
				page: 1,
			});
		}
	}
	return arrPager;
}