app.service('DataService', ['$http', 'baseServiceUrl', function($http, baseServiceUrl){
	this.getAllBooks = function(callback){
		var requestObject = {
			url: baseServiceUrl + '/books/',
			method: 'GET'
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.getUserShelves = function(callback, userID){
		var requestObject = {
			url: baseServiceUrl + '/shelves/getshelvesbyuser/' + userID,
			method: 'GET'
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.getBookReviews = function(callback, bookID){
		var requestObject = {
			url: baseServiceUrl + '/reviews/getreviewsbybook/' + 'BookID=' + bookID,
			method: 'GET'
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.addBookReview = function(callback, bookID, userID){
		var requestObject = {
			url: baseServiceUrl + '/users/reviews',
			method: 'Post',
			data: {
				BookId: bookID,
				userID: userID
			}
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.addBook = function(callback, title, resume, isbn, pagecount, coverimage, authors, genres){
		var requestObject = {
			url: baseServiceUrl + '/admin/books',
			method: 'POST',
			data: {
				Title: title,
				Resume: resume,
				Isbn: isbn, 
				NumberOfPages: pagecount,
				Authors: authors,
				Genres: genres,
				CoverImage: coverimage
			}
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.addGenre = function(callback, genreName){
		var requestObject = {
			url: baseServiceUrl + '/admin/genres',
			method: 'POST',
			data: {
				Name: genreName,
			}
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.addAuthor = function(callback, firstName, lastName, picture, website, information){
		var requestObject = {
			url: baseServiceUrl + '/admin/authors',
			method: 'POST',
			data: {
				FirstName: firstName,
				LastName: lastName,
				Picture: picture,
				Website: website,
				Information : information
			}
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.addUserShelf = function(callback, shelfName, UserId){
		var requestObject = {
			url: baseServiceUrl + '/users/shelves',
			method: 'POST',
			data: {
				Name: shelfName,
				UserId: UserId
			}
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};

	this.addBookToShelf = function(callback, shelfId, bookId){
		var requestObject = {
			url: baseServiceUrl + '/users/shelves/' + shelfId,
			method: 'PUT',
			data: {
				BookId: BookId
			}
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});	
	};

	this.removeBookFromShelf = function(callback, shelfId, bookId){
		var requestObject = {
			url: baseServiceUrl + '/users/shelves/deletebook/' + shelfId,
			method: 'DELETE',
			data: {
				BookId: BookId
			}
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});	
	};

	this.removeShelf = function(callback, shelfId){
		var requestObject = {
			url: baseServiceUrl + '/users/shelves/' + shelfId,
			method: 'DELETE'
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});	
	};

	this.editBook = function(callback, bookId, title, resume, isbn, pagecount, coverimage, authors, genres){
		var requestObject = {
			url: baseServiceUrl + '/admin/Books/' + bookId,
			method: 'PUT',
			data: {
				Title: title,
				Resume: resume,
				Isbn: isbn, 
				NumberOfPages: pagecount,
				Authors: authors,
				Genres: genres,
				CoverImage: coverimage
			}
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.editGenre = function(callback, genreId, genreName){
		var requestObject = {
			url: baseServiceUrl + '/admin/genres/' + genreId,
			method: 'PUT',
			data: {
				Name: genreName,
			}
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.editAuthor = function(callback, authorId, firstName, lastName, picture, website, information){
		var requestObject = {
			url: baseServiceUrl + '/admin/authors/' + authorId,
			method: 'PUT',
			data: {
				FirstName: firstName,
				LastName: lastName,
				Picture: picture,
				Website: website,
				Information : information
			}
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};

	this.removeBook = function(callback, bookId){
		var requestObject = {
			url: baseServiceUrl + '/admin/books/' + bookId,
			method: 'DELETE'
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.removeGenre = function(callback, genreId){
		var requestObject = {
			url: baseServiceUrl + '/admin/genres/' + genreId,
			method: 'DELETE'
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
	this.removeAuthor = function(callback, authorId){
		var requestObject = {
			url: baseServiceUrl + '/admin/authors/' + authorId,
			method: 'DELETE'
		};
		$http(requestObject).then(function(callback){
			return callback(response);
		});
	};
}]);