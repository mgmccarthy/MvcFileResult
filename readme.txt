This project encapsulates the creation of file-format-specific MVC FileResults based on generics and the template method
- \FileResultClasses: includes one class per "format type" and FileResultFor<T> which does the actual work
	- the implementation of ReturnValueDelimited if forced on inheriting classes to provide the delimiter for values being writtten
- \Models\Model: a very generic Model class to populate with tests data. This model class's data will be returned via the choosen file formatter class on the HttpResponse stream
- \Controllers\HomeContoller: uncomment different file formatter classes to see the files returned via the HttpResponse stream