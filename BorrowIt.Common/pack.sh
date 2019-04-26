#!/bin/bash

dotnet pack ./BorrowIt.Common/BorrowIt.Common.csproj -o ../../../Dlls/
dotnet pack ./BorrowIt.Common.Mongo/BorrowIt.Common.Mongo.csproj -o ../../../Dlls/
dotnet pack ./BorrowIt.Common.Rabbit/BorrowIt.Common.Rabbit.csproj -o ../../../Dlls/

