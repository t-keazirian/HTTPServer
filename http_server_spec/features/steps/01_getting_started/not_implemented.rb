require "./features/steps/shared.rb"

class Spinach::Features::NotImplemented < Spinach::FeatureSteps
  include Shared::Standard

  step 'I make a CONNECT request to "/simple_get"' do
    @response = Requests.connect("/simple_get")
  end
end
