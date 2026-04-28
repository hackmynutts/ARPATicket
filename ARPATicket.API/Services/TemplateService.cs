namespace ARPATicket.API.Services
{
    public abstract class TemplateService<TAddDTO, TModel, TResultDTO>
    {
        //definimos el template
        //define el orden de los pasos a seguir para crear una entidad, pero deja la implementación de cada paso a las clases derivadas

        public async Task<TResultDTO> AddAsync(TAddDTO dto) //es lo mismo que TicketAddDTO, pero lo hacemos genérico para que pueda ser reutilizado por otras entidades
        {
            var externalData = await GetExternalDataAsync(dto);
            var model = MapToModel(dto, externalData);
            var result = await SaveAsync(model);
            return MapToResultDTO(result);
        }
        //procedimientos que los hijos implementarán, cada entidad tendrá su propia forma de obtener datos externos, mapear a modelo, guardar y mapear a DTO de resultado
        protected abstract Task<string> GetExternalDataAsync(TAddDTO dto);
        protected abstract TModel MapToModel(TAddDTO dto, string externalData);
        protected abstract Task<TModel> SaveAsync(TModel model);
        protected abstract TResultDTO MapToResultDTO(TModel model);
    }
}