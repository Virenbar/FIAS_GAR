''' <summary>
''' Структура для использования в <see cref="Progress(Of T)"/>
''' </summary>
Public Structure TaskProgress

#Region "Ctor"

	''' <summary>
	''' Задает числовой прогресс
	''' </summary>
	Public Sub New(Value As Integer, Max As Integer)
		Me.Value = Value
		Me.Max = Max
		Percent = Value / Max * 100
		HasValue = True
	End Sub

	''' <summary>
	''' Задает процент
	''' </summary>
	Public Sub New(Percent As Integer)
		Me.Percent = Percent
		Value = Percent
		Max = 100
		HasValue = True
	End Sub

	''' <summary>
	''' Задает строковый и числовой прогресс
	''' </summary>
	Public Sub New(Status As String, Value As Integer, Max As Integer)
		Me.New(Value, Max)
		Me.Status = Status
		HasStatus = True
	End Sub

	''' <summary>
	''' Задает строковый прогресс и процент
	''' </summary>
	Public Sub New(Status As String, Percent As Integer)
		Me.New(Percent)
		Me.Status = Status
		HasStatus = True
	End Sub

	''' <summary>
	''' Задает строковый прогресс
	''' </summary>
	Public Sub New(Status As String)
		Me.Status = Status
		HasStatus = True
	End Sub

#End Region

#Region "Properties"

	''' <summary>
	''' Есть ли значение у Status
	''' </summary>
	Public ReadOnly Property HasStatus As Boolean

	''' <summary>
	''' Есть ли значения у Value, Max и Percent
	''' </summary>
	Public ReadOnly Property HasValue As Boolean

	''' <summary>
	''' Максимальное значение
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property Max As Integer

	''' <summary>
	''' Процент в формате 100.00
	''' </summary>
	Public ReadOnly Property Percent As Double

	''' <summary>
	''' Строковый статус
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property Status As String

	''' <summary>
	''' Текущие значение
	''' </summary>
	''' <returns></returns>
	Public ReadOnly Property Value As Integer

#End Region

End Structure