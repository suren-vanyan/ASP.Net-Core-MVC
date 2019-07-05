//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace VegaStarter.Mapper
//{
//    public class MapperExtension
//    {
//        private static IMapper _mapper;

//        public static void Init(IMapper mapper)
//        {
//            _mapper = mapper;
//        }

//        public static ToViewModel ToViewModel<FromEntity, ToViewModel>(this FromEntity entity, Func<ToViewModel, FromEntity, ToViewModel> convertor = null) where FromEntity : BaseEntity where ToViewModel : BaseViewModel
//        {
//            ToViewModel ViewModel = _mapper.Map<FromEntity, ToViewModel>(entity);
//            if (convertor != null)
//            {
//                ViewModel = convertor(ViewModel, entity);
//            }

//            return ViewModel;

//        }

//        public static IEnumerable<ToViewModel> ToViewModelList<FromEntity, ToViewModel>(this IEnumerable<FromEntity> entities, Func<ToViewModel, FromEntity, ToViewModel> convertor = null) where FromEntity : BaseEntity where ToViewModel : BaseViewModel
//        {
//            return entities.Select(
//                entity =>
//                {
//                    ToViewModel ViewModel = ToViewModel<FromEntity, ToViewModel>(entity);
//                    if (convertor != null)
//                    {
//                        ViewModel = convertor(ViewModel, entity);
//                    }
//                    return ViewModel;
//                }).ToList<ToViewModel>();
//        }

//        public static ToEntity ToEntity<FromViewModel, ToEntity>(this FromViewModel model, Func<ToEntity, FromViewModel, ToEntity> convertor = null) where ToEntity : BaseEntity where FromViewModel : BaseViewModel
//        {
//            ToEntity Entity = _mapper.Map<FromViewModel, ToEntity>(model);

//            if (convertor != null)
//            {
//                Entity = convertor(Entity, model);
//            }

//            return Entity;
//        }

//        public static IEnumerable<ToEntity> ToEntityList<FromViewModel, ToEntity>(this IEnumerable<FromViewModel> viewModels, Func<ToEntity, FromViewModel, ToEntity> convertor = null) where ToEntity : BaseEntity where FromViewModel : BaseViewModel
//        {
//            return viewModels.Select(
//               viewModel =>
//               {
//                   ToEntity Entity = ToEntity<FromViewModel, ToEntity>(viewModel);
//                   if (convertor != null)
//                   {
//                       Entity = convertor(Entity, viewModel);
//                   }
//                   return Entity;
//               }).ToList<ToEntity>();
//        }
//    }
//}
//}
