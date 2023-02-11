var connection = new signalR.HubConnectionBuilder().withUrl("/messagehub").build();
connection.start();


/* Ajax Lay Du Lieu Len*/
function loadData(_page) {
	$.ajax({
		type: 'GET',
		url: '/Admin/Customer/GetList?page=' + _page,
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
					'<li><a class="border-radius-0 btn btn-outline-secondary ' +
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
			console.log(page)
			loadData(page);
		});
	});
};
function render(data) {
	return data.forEach(function (res, index) {
		var tr = $('<tr>').appendTo('tbody');
		var td = `		<td>${res.id}</td>
						<td >${res.name}</td>
						<td >${res.username}</td>
						<td >${res.email}</td>
						${SoSanh(res.isLock)}<
						<td data-id="${res.id}">
							<div class="btn-group text-center" role="group">
								<a href="#" class="btn btn-sm btn-outline-secondary js-update" data-id=${res.id} data-toggle="UserCustomer_modal" data-bs-toggle="modal" data-bs-target="#UserCustomer_modal">
									<i class="fas fa-edit"></i>
								</a>
								<a href="#" id="sa-warning" class="btn btn-sm btn-outline-secondary js-delete waves-effect waves-light" data-id="${res.id}">
									<i class="fas fa-trash-alt"></i>
								</a>
							</div>
						</td>`
		$(td).appendTo(tr);
	});
};

window.addEventListener('load', () => {
	loadData();
});

const SoSanh = (data, id) => {
	if (data == true) {
		return `<td class="text-center" data-id=${id} ><i class="fas fa-2x fa-user-slash text-danger"></i></td>`
	}
	return `<td class="text-center" data-id=${id}><i class="fas fa-2x fa-user-check text-success"></i></td>`
}

// btn huy modal
$("#btnClose").on("click", function () {
	$("#Id").val(null);
	$('#UserCustomer_modal').modal('hide')
	$("#UserCutomerForm")[0].reset();
	$("#UserCutomerForm").find("#IsLock").attr('checked', false);
});
// btn lưu modal
$("#btnSaveCustomer").on("click", function (ev) {
	ev.preventDefault();
	var form = $("#UserCutomerForm");
	var data = new FormData(form[0]);
	$.ajax({
		url: "/Admin/Customer/Update",
		data: data,
		dataType: 'json',
		type: "POST",
		processData: false,
		contentType: false,
		success: function (res) {
			if (res == true) {
				$("#UserCutomerForm")[0].reset();
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
})

//js Update
$(document).on("click", ".js-update", function (ev) {
	ev.preventDefault();
	var form = $("#UserCutomerForm");
	var id = $(ev.currentTarget).closest("td").attr("data-id");
	$.get("/Admin/Customer/Get", { id: id }, function (data, textStatus, jqXHR) {
		form.find("#Id").val(data.id);
		form.find("#Name").val(data.name);
		form.find("#Username").val(data.username);
		form.find("#PhoneNumber").val(data.phoneNumber);
		form.find("#Address").val(data.address);
		form.find("#Email").val(data.email);
		if (data.isLock) {
			form.find("#IsLock").attr('checked',true);
		}
	});
});

// js xóa
$(document).on('click', '.js-delete', function (ev) {
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
		cancelButtonText : 'Hủy'
	}).then((result) => {
		if (result.isConfirmed) {
			$.ajax({
				type: "DELETE",
				url: "/Admin/Customer/Remove",
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
					}
				}

			})
		}
	});
});


// phan trang js 
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